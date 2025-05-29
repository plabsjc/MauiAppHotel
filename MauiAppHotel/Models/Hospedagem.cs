using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QuantidadeAdultos { get; set; }

        public int QuantidadeCriancas { get; set; }

        public DateTime DataCheckIn { get; set; }

        public DateTime DataCheckOut { get; set; }

        public int Estadia { get => DataCheckOut.Subtract(DataCheckIn).Days; }

        public double ValorTotal { 
            get => (QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto 
                + QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca) * Estadia;
        }



    }
}
