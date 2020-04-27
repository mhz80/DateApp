using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DateMePlease.Models
{
  public class PhotoViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Url { get; set; }
    public bool IsMain { get; set; }
    
    [Required]
    public string Description { get; set; }
  }
}
