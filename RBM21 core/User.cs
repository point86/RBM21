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
        public DateTime Time { get; set; }
        public int CreditoResiduo { get; set; }
        public string UserCode { get; set; }
        public bool Active { get; set; }

        public User() { //non initialized data
            this.Position = -1;
            this.Nome = " --EMPTY-- ";
            this.Key  = " --EMPTY-- ";
            this.CreditoResiduo = -1;
            this.Time = new DateTime(1974, 7, 10, 7, 10, 24); ;            
            this.UserCode = " --EMPTY-- ";
            this.Active = false;
        }
        public User(int Position, string Nome, string Key, int CreditoResiduo, DateTime Time, string UserCode, bool Active)
        {
            this.Position = Position;
            this.Nome = Nome;
            this.Key = Key;
            this.CreditoResiduo = CreditoResiduo;
            this.Time = Time;
            this.UserCode = UserCode;
            this.Active = Active;
        }       
        public override string ToString()
        {
            return String.Format("Nome: {0}, Position(File): {1}, Key: {2}, LastTime: {3}, Credito Residuo: {4}, Usercode (interno): \"{5}\", Active: {6}",
                                        this.Nome, this.Position, this.Key, this.Time, this.CreditoResiduo, this.UserCode, this.Active);
        }
    }
   
}
