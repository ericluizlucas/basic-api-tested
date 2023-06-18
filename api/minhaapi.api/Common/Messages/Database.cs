namespace minhaapi.Common.Messages
{
    public static class Database
    {
        public static string ConnectionError => "Erro ao realizar conexão.";
        public static string RegisterNotFound => "Registro não encontrado.";
        public static string CategoryNotFound => "Categoria não encontrada.";

        public static string SelectDatabaseError => "Erro ao buscar registro no banco de dados.";
        public static string UpdateDatabaseError => "Erro ao atualizar registro no banco de dados.";
        public static string InsertDatabaseError => "Erro ao inserir registro no banco de dados.";
    } 
}