﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace validaCpfCnpj.Models
{
    public class Entidade
    {   
        public int Id { get; set; }

        [Required]
        public string CpfOuCnpj { get; set; }
    }
}