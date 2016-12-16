using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_6
{
    class FachadaCuentas
    {
        //1 = Caja de Ahorro | 2= Cuenta Corriente
        private CuentasS iCuentas = new CuentasS();

        public CuentasS Cuenta
        {
            get { return this.iCuentas; }
        }


        public Cuenta MostrarCuenta(int pCuenta)
        {
            if (pCuenta == 1)//CAJA DE AHORRO
                return this.iCuentas.CajaAhorro;
            else
                return this.iCuentas.CuentaCorriente; //CUENTA CORRIENTE
        }

        public void AcreditarCuenta(int pCuenta, double pSaldo)
        {
            if (pCuenta == 1) iCuentas.CajaAhorro.AcreditarSaldo(pSaldo); //CAJA DE AHORRO
            else iCuentas.CuentaCorriente.AcreditarSaldo(pSaldo); //CUENTA CORRIENTE
        }

        public Boolean DebitarCuenta(int pCuenta, double pSaldo)
        {
            bool mResultado = false;

            switch (pCuenta)
            {
                case 1://CAHA DE AHORRO
                    {
                        if (iCuentas.CajaAhorro.DebitarSaldo(pSaldo)) mResultado = true;
                        break;
                    }
                case 2://CUENTA CORRIENTE
                    {
                        if (iCuentas.CuentaCorriente.DebitarSaldo(pSaldo)) mResultado = true;
                        break;
                    }
            }

            return mResultado;

        }

        public Boolean Transferir(int pCuenta1, double pSaldo)
        {
            bool mResultado = false;

            switch (pCuenta1)
            {
                case 1://TRASFERENCIAS DESDE CAJAHORRO A CUENTA CORRIENTE
                    {
                        if (DebitarCuenta(1, pSaldo))
                        {
                            AcreditarCuenta(2, pSaldo);
                            mResultado = true;
                        }
                        break;
                    }
                case 2:////TRASFERENCIAS DESDE CUENTA CORRIENTE A CAJAHORRO 
                    {
                        if (DebitarCuenta(2, pSaldo))
                        {
                            AcreditarCuenta(1, pSaldo);
                            mResultado = true;
                        }
                        break;
                    }
            }

            return mResultado;
        }
    }
}