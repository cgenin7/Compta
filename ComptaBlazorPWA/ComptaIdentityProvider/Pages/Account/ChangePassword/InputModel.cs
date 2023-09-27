// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.
using System.ComponentModel.DataAnnotations;

namespace ComptaIdentityProvider.Pages.ChangePassword;

public class InputModel
{
    [Required]
    public string Password { get; set; }
}