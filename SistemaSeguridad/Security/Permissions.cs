namespace SistemaSeguridad.Security
{
    /// <summary>
    /// Catálogo centralizado de permisos del sistema chocoAdmin.
    /// </summary>
    public static class Permissions
    {
        // ---- Productos ----
        public const string Productos_Ver = "Productos.Ver";
        public const string Productos_Crear = "Productos.Crear";
        public const string Productos_Editar = "Productos.Editar";
        public const string Productos_Eliminar = "Productos.Eliminar";

        // ---- Usuarios ----
        public const string Usuarios_Ver = "Usuarios.Ver";
        public const string Usuarios_GestionarRoles = "Usuarios.GestionarRoles";

        // ---- Reportes ----
        public const string Reportes_Ver = "Reportes.Ver";

        // Lista de todos los permisos, para usar en seed y policies
        public static IReadOnlyList<string> All => new[]
        {
            Productos_Ver,
            Productos_Crear,
            Productos_Editar,
            Productos_Eliminar,
            Usuarios_Ver,
            Usuarios_GestionarRoles,
            Reportes_Ver
        };
    }
}
