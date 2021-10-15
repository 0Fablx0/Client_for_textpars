using Client_for_textpars.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Client_for_textpars.Controller;

namespace Client_for_textpars.Model_View
{
    class MainWindowShell: Base.Base
    {
        APIController client = new APIController();

        #region Привязка перемменных к форме
        private string _inputID = string.Empty;
        public string inputID
        {
            get => _inputID;
            set => Set(ref _inputID, value);
        }


        private ObservableCollection<ParsedText> _parsText = new ObservableCollection<ParsedText>() { new ParsedText()};
        public ObservableCollection<ParsedText> parsText
        {
            get => _parsText;
        }

        #endregion

        public ICommand getTextFromServer { get; }

        private async void OnRefreshChatExecutedAsync(object p)
        {
            string Text = await client.APIGetText();
        }

        private bool CanRefreshChatExecuted(object p) => true;

        public MainWindowShell()
        {
            
        }
    }
}
