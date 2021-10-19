using Client_for_textpars.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Client_for_textpars.Controller;
using Client_for_textpars.Model_View.Base;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows;

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

        private string _wrongID = string.Empty;
        public string wrongID
        {
            get => _wrongID;
            set => Set(ref _wrongID, value);
        }

        private ObservableCollection<ParsedText> _parsText = new ObservableCollection<ParsedText>();
        public ObservableCollection<ParsedText> parsText
        {
            get => _parsText;
        }

        private bool _buttonSearchEnableState = true;
        public bool buttonSearchEnableState 
        { 
            get => _buttonSearchEnableState;
            set => Set(ref _buttonSearchEnableState, value); 
        }
        #endregion

        public ICommand getTextFromServer { get; }

        private async void OnRefreshChatExecutedAsync(object p)
        {
            buttonSearchEnableState = false;
            _parsText.Clear();

            (List<int> corectID,List<string> wrongID) parsIDResult = Logic.parsInputID(_inputID.ToString());
            wrongID = string.Join(",", parsIDResult.wrongID); ;
            List<string> Text = await client.getTextListFromServerAsync(parsIDResult.corectID);
            

            foreach (var x in Text)
            {
                ParsedText parsedTextUnit = new ParsedText();
                parsedTextUnit.Text = x;
                parsedTextUnit.countWords=Logic.getCountWords(x);
                parsedTextUnit.countVowelLetter = Logic.getCountVowelLetter(x);
                _parsText.Add(parsedTextUnit);
            }
            buttonSearchEnableState = true;
        }

        private bool CanRefreshChatExecuted(object p) => true;

        public MainWindowShell()
        {
            getTextFromServer = new ActionCommand(OnRefreshChatExecutedAsync, CanRefreshChatExecuted);
        }
    }
}
