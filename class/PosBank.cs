using POS_PC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dentistry
{
   public class PosBank
    {

       public string BankMellat(string ConnectionType,string PortName,int BoundRate,string Amount)
       {
           Globals.POSPC_CommunicationType = ConnectionType;
           Transaction TXN = new Transaction();
           POS_PC.Transaction.return_codes retCode = Transaction.return_codes.ERR_POS_PC_OTHER;
           TXN.PC_PORT_Name = PortName;
           TXN.PC_PORT_BaudRate = BoundRate;
           TXN.PC_PORT_ReadTimeout = 180000;

           retCode = TXN.Debits_Goods_And_Service(Amount, "", "");

           if (retCode == Transaction.return_codes.RET_OK)
           {
              
               return TXN.TraceNumber;//شماره مرجع
           }
           else
           {
               return "";
           }
       }
    }
}
