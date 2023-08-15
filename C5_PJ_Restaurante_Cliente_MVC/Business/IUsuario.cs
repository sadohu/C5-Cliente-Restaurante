﻿using C5_PJ_Restaurante_Cliente_MVC.Models;

namespace C5_PJ_Restaurante_Cliente_MVC.Business
{
    public interface IUsuario
    {
        Task<Usuario> Login(Usuario usuario);
        Task<Usuario> Add(Usuario usuario);

    }
}
