using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Payment
{
    public class BankCodeName
    {
        public string name { get; set; }
        //public string BANKCODE { get; set; }
    }
    //public class BankListResponseDto
    //{
    //    public List<BankCodeName> response { get; set; }

    //}

    public class BankListDto
    {
        public BankCodeName[] data { get; set; }

    }
}
