using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MWIE.Models.ViewModel
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; }
    }

    public class ClientViewModelEdit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [DefaultValue("true")]
        public bool IsActive { get; set; }
    }
}
