﻿namespace DockerComposeSample.Entities;

public class User
{
    public Guid Id { get; set; }    
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

}
