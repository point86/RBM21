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
        public DateTime Time { get; set; }
        //public List<string> Entrances { get; set; }
        public List<string> Entrances; //FIXME This is not a backing field!!!!!!

        public User() { //non initialized data
            this.Position = -1;
            this.Nome = " --EMPTY-- ";
            this.Key  = " --EMPTY-- ";
            this.CreditoResiduo = -1;
            this.Entrances = new List<string>();
            this.UserCode = " --EMPTY-- ";
            this.Active = false;
        }
        public User(int Position, string Nome, string Key, int CreditoResiduo, List<string> Entrances, string UserCode, bool Active)
        {
            this.Position = Position;
            this.Nome = Nome;
            this.Key = Key;
            this.CreditoResiduo = CreditoResiduo;
            this.Entrances = Entrances;
            this.UserCode = UserCode;
            this.Active = Active;
        }       
        public override string ToString()
        { //FIXME entrances are not displayed. maybe show only the last one?
            return String.Format("Nome: {0}, Position(File): {1}, Key: {2}, Credito Residuo: {3}, Usercode (interno): \"{4}\", Active: {5}",
                                        this.Nome, this.Position, this.Key, this.CreditoResiduo, this.UserCode, this.Active);
        }
    }
   
}
