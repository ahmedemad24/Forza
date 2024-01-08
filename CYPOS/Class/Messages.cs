using System;
using System.Collections.Generic;
using System.Text;

namespace cypos
{
    static class Messages
    {
        #region About Messages Class

        //Writter by Rinesh PK on 17/09/2012

        #endregion

        #region Static Functions

        public static void InformationMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "LinkPOS™",MyMessageBox.Buttons.OK,MyMessageBox.Icons.Information );
        }

        public static void WarningMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "LinkPOS™",MyMessageBox.Buttons.OK,MyMessageBox.Icons.Warning);
        }
        public static void ErrorMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }
        public static void StopMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Stop);
        }
        public static bool QuestionMessage(string strMsg)
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox(strMsg, "LinkPOS™",MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question))==MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;
        }

        public static void SavedMessage()
        {
            MyMessageBox.ShowBox("Saved successfully", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void UpdatedMessage()
        {
            MyMessageBox.ShowBox("Updated successfully ", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void DeletedMessage()
        {
            MyMessageBox.ShowBox("Deleted successfully ", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void ExceptionMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }

        public static void ExceptionMessage(string strMsg, string strCustomMessege)
        {
            MyMessageBox.ShowBox(strMsg + " " + strCustomMessege, "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }

        public static void ReferenceExistsMessage()
        {
            MyMessageBox.ShowBox("You can't delete,reference exist", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Warning);
        }

        public static void ReferenceExistsMessageWithString(string strReference)
        {
            MyMessageBox.ShowBox("You can't delete,reference exist in " + strReference, "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Warning);
        }

        public static void AlreadyExistMessage()
        {
            MyMessageBox.ShowBox("Already exists ", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void NoPrivillageMessage()
        {
            MyMessageBox.ShowBox("You are not privileged, contact administrator", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void FillAllDetailsMessage()
        {
            MyMessageBox.ShowBox("Please fill all mandatory details", "LinkPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }
      

        public static bool DeleteMessage()
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox("Are you sure to delete ? ", "LinkPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question))==MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;

        }
        public static bool DeleteMessageCustom(string strMsg)
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox(strMsg, "LinkPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;
        }

        public static bool CloseMessage()
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox("Are you sure to exit ? ", "LinkPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;

        }
        public static void CloseMessage(System.Windows.Forms.Form frm)
        {
            if ((MyMessageBox.ShowBox("Are you sure to exit ? ", "LinkPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                
                frm.Close();
            }
        }
        #endregion
    }
}
