using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP01.Model
{
    public class Funcionario
    {
        public static string TipoContrato { get; }
        public int CodigoRegistro { get; set; }
        public string Nome { get; set; }
        public Genero Genero { get; set; }
    }
    public class FuncionarioCLT : Funcionario
    {
        public Decimal Salario { get; set; }
        public bool CargoConfianca { get; set; }

        public decimal CustoMensalCLT()
        {
            decimal totalSalario = Salario;

            totalSalario += Salario * 0.1111m; // férias
            totalSalario += Salario * 0.0833m; // 13° salário
            totalSalario += Salario * 0.08m; //  FGTS
            totalSalario += Salario * 0.04m; // rescisão
            totalSalario += Salario * 0.0793m; //  previdenciário

            return totalSalario;
        }

        public override string ToString()
        {
            return $"\nCodigo de registro: {CodigoRegistro}\nNome: {Nome}\nGenero: {Genero}" +
                   $"\nSalario: {Math.Round(Salario,2)}\nCargo de confiança: {(CargoConfianca == true ? "Sim" : "Não")}\n";
        }
    }
    public class FuncionarioPJ : Funcionario
    { 
        public Decimal ValorHora { get; set; }
        public int QuantidadeHoras { get; set; }
        public string CNPJ { get; set; }

        public decimal CustoMensalPJ()
        {
            return ValorHora * QuantidadeHoras;            
        }
        public decimal CustoMensalPJ(int horasExtras)
        {
            if (horasExtras < 0)
                throw new ArgumentException("Valor invalido!");
            return (ValorHora * QuantidadeHoras) + (ValorHora * 1.5m * horasExtras);             
        }
        public override string ToString()
        {
            return $"\nCodigo de registro: {CodigoRegistro}\nNome: {Nome}\nGenero: {Genero}" +
                   $"\nValor por hora: {Math.Round(ValorHora,2)}\nQuantidade de horas: {QuantidadeHoras}\nCNPJ: {CNPJ}\n";
        }
    }
    public enum Genero
    {
        Masculino, Feminino, Outros
    }
}
