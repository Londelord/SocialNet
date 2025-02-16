﻿namespace SocNetBack.Application.Interfaces;

public interface IPasswordHasher
{
    string Generate(string password);
    bool Verify(string hashedPassword, string providedPassword);
}