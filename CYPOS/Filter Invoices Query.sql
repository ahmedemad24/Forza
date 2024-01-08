declare @fromDate date =cast('' as date)
select @fromDate

declare @toDate date = getdate() 
declare @shiftId int = null
declare @username varchar(150) =null



select * from 
( SELECT 
	invoice_id, invoice_no
	, CASE 
		WHEN i.order_type = 1 THEN 'DINE IN' 
		WHEN i.order_type = 2 THEN 'TAKE AWAY' 
		WHEN i.order_type = 3 THEN 'DELIVERY' 
		WHEN i.order_type = 4 THEN 'PICK UP' 
	END order_type
	, 'Close' invoice_status, cast(log_date as date) invoice_date ,cast(log_date as time) invoice_time
	, CASE 
		WHEN isCanceled = 1 THEN 'Canceled' 
		WHEN isGifted = 1 THEN 'Gifted' 
		ELSE payment_type 
	END payment_type
	, user_name, discount_rate, payment_amount, shift_id, log_date
	, paid_amount, change_amount, due_amount, isnull(note, 'ClosedINV') note 
FROM tbl_InvoiceHeader i 
union all
Select 
	id, invoiceNo
	, CASE 
		WHEN t.order_type = 1 THEN 'DINE IN' 
		WHEN t.order_type = 2 THEN 'TAKE AWAY' 
		WHEN t.order_type = 3 THEN 'DELIVERY' 
		WHEN t.order_type = 4 THEN 'PICK UP' 
		END order_type
	,'Open' invoice_status,cast(log_date as date) invoice_date ,cast(log_date as time) invoice_time , payment_type
	, user_name, discount_rate, payment_amount, shift_id, log_date, paid_amount, change_amount, due_amount, isnull(note, 'fromTemp') note 
FROM tbl_TempHeader t ) tbl
where 
	(tbl.shift_id = @shiftId or @shiftId is null) and
	(tbl.user_name = @username or @username is null) and
	--(tbl.invoice_no = @udd or @udd is null) and
	((@toDate is null and @fromDate is null) or
	 (@toDate >= tbl.log_date and @fromDate is null) or
	 (@todate is null and @fromDate <= log_date) or
	 (@toDate >= tbl.log_date and @fromDate <= log_date))