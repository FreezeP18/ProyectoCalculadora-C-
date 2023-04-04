using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Operaciones
    {
        //propiedades set y get
        public float Numero1{get; set;}
        public float Numero2{get; set;}

        //metodo para sumar
        public float Sumar()
        {
            return this.Numero1 + this.Numero2;
        }
        //metodo para restar
        public float Restar()
        {
            return this.Numero1 - this.Numero2;
        }
        //metodo para multiplicar
        public float Multiplicar()
        {
            return this.Numero1 * this.Numero2;
        }
        //metodo para dividir
        public float Dividir()
        {
            return this.Numero1 / this.Numero2;
        }
    }
}
