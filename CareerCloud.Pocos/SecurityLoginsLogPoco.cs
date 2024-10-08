﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CareerCloud.Pocos;

[Table(name: "Security_Logins_Log")]
public class SecurityLoginsLogPoco : IPoco
{
    [Key]
    public Guid Id { get; set; }

    public Guid Login {  get; set; }

    [Column(name: "Source_IP")]
    public string SourceIP { get; set; }

    [Column(name: "Logon_Date")]
    public DateTime LogonDate { get; set; }

    [Column(name: "Is_Succesful")]
    public bool IsSuccesful {  get; set; }

    [JsonIgnore]
    public virtual SecurityLoginPoco SecurityLogin { get; set; }
}
