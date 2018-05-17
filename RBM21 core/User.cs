using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBM21_core
{   
    class User
    {
        public int Position { get; set; }
        public string Nome { get; set; }
        public string Key { get; set; }        
        public int CreditoResiduo { get; set; }
        public string UserCode { get; set; }
        public bool Active { get; set; }
        public DateTime Time { get; set; } //used by FileReader - RBM21Core
        public List<string> Entrances; //user by HardwareSync() - RBM21Core
        public DateTime DataInserimento { get; set; } //used by RBM21Core

        public User() { //non initialized data
            this.Position = -1;
            this.Nome = " --EMPTY-- ";
            this.Key  = " --EMPTY-- ";
            this.CreditoResiduo = -1;
            this.Entrances = new List<string>();
            this.UserCode = " --EMPTY-- ";
            this.Active = false;
            this.DataInserimento = new DateTime(1980, 1, 1);
        }
        public User(string Nome, string Key, int CreditoResiduo, List<string> Entrances, string UserCode, bool Active)
        {
        //    this.Position = Position;
            this.Nome = Nome;
            this.Key = Key;
            this.CreditoResiduo = CreditoResiduo;
            this.Entrances = Entrances;
            this.UserCode = UserCode;
            this.Active = Active;
        }       
        public override string ToString()
        { 
            return String.Format("Nome: {0}, Key: {1}, Credito Residuo: {2}, Usercode (interno): \"{3}\", Active: {4},Data Inserimento: {5}",
                                        this.Nome, this.Key, this.CreditoResiduo, this.UserCode, this.Active, this.DataInserimento);
        }
        public string ToVerticalString()
        { 
            return String.Format("Nome: {0}\r\nKey: {1}\r\nCredito Residuo: {2}\r\nUsercode (interno): \"{3}\"\r\nActive: {4}\r\nData Inserimento: {5}",
                                        this.Nome, this.Key, this.CreditoResiduo, this.UserCode, this.Active, this.DataInserimento);
        }
    }
   
}
