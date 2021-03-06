﻿namespace TurboRango.Dominio
{
    public class Restaurante : Entidade
    {
        /// <summary>
        /// Capacidade (lotação máxima) do restaurante.
        /// </summary>
        public int? Capacidade { get; set; }
        public string Nome { get; set; }
        public string url { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual Localizacao Localizacao { get; set; }
        public Categoria Categoria { get; set; }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        internal string Imprimir(int x)
        {
            return null;
        }
        */
    }
}
