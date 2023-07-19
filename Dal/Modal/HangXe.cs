﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Modal
{
    public class HangXe
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TrangThai { get; set; }
        public ICollection<LoaiXe> LoaiXe { get; set; }
    }
}
