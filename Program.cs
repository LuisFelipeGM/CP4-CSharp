using CP01.Model;

bool encerrar = false;
IList<FuncionarioPJ> listaFuncionariosPJ = new List<FuncionarioPJ>();
IList<FuncionarioCLT> listaFuncionariosCLT = new List<FuncionarioCLT>();

while (true)
{

    if (encerrar)
    {
        Console.WriteLine("Encerrando...");
        break;
    }

    Console.WriteLine("\n1 - Cadastro");
    Console.WriteLine("2 - Consulta");
    Console.WriteLine("3 - Editar");
    Console.WriteLine("4 - Sair");
    Console.Write("Digite a sua opção: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            {
                Console.WriteLine("\n1 - Cadastrar Funcionario CLT");
                Console.WriteLine("2 - Cadastrar Funcionario PJ");
                Console.WriteLine("3 - Sair");
                Console.Write("Digite a sua opção: ");

                string? opcaoCadastro = Console.ReadLine();

                switch (opcaoCadastro)
                {
                    case "1":
                        {
                            FuncionarioCLT cadastroCLT = new FuncionarioCLT();

                            Console.Write("Digite o codigo de registro: ");
                            cadastroCLT.CodigoRegistro = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome: ");
                            cadastroCLT.Nome = Console.ReadLine();
                            Console.Write("Digite o genero, <F> para Feminino, <M> para Masculino e <O> para Outros: ");
                            string? opcaoGenero = Console.ReadLine();

                            if (opcaoGenero.ToUpper() == "F")
                                cadastroCLT.Genero = Genero.Feminino;
                            else if (opcaoGenero.ToUpper() == "M")
                                cadastroCLT.Genero = Genero.Masculino;
                            else if (opcaoGenero.ToUpper() == "O")
                                cadastroCLT.Genero = Genero.Outros;
                            else
                            {
                                Console.WriteLine("Opção invalida!");
                                break;
                            }

                            Console.Write("Digite o valor do salario: ");
                            string? salario = Console.ReadLine();
                            decimal valorSalario = 0;

                            if(decimal.TryParse(salario, out valorSalario))
                                cadastroCLT.Salario = valorSalario;
                            else
                                Console.WriteLine("Valor invalido!");
                            Console.WriteLine("Digite cargo confiança, <S> para Sim, <N> Não: ");
                            string? opcaoConfianca = Console.ReadLine();

                            if (opcaoConfianca.ToUpper() == "S")
                                cadastroCLT.CargoConfianca = true;
                            else if (opcaoConfianca.ToUpper() == "N")
                                cadastroCLT.CargoConfianca = false;
                            else
                            {
                                Console.WriteLine("Opção invalida!");
                                break;
                            }

                            listaFuncionariosCLT.Add(cadastroCLT);
                            Console.WriteLine("Cadatro finalizado");
                            break;
                        }
                    case "2":
                        {
                            FuncionarioPJ cadastroPJ = new FuncionarioPJ();

                            Console.Write("Digite o codigo de registro: ");
                            cadastroPJ.CodigoRegistro = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome: ");
                            cadastroPJ.Nome = Console.ReadLine();
                            Console.Write("Digite o genero, <F> para Feminino, <M> para Masculino e <O> para Outros: ");
                            string? opcaoGenero = Console.ReadLine();

                            if (opcaoGenero.ToUpper() == "F")
                                cadastroPJ.Genero = Genero.Feminino;
                            else if (opcaoGenero.ToUpper() == "M")
                                cadastroPJ.Genero = Genero.Masculino;
                            else if (opcaoGenero.ToUpper() == "O")
                                cadastroPJ.Genero = Genero.Outros;
                            else
                            {
                                Console.WriteLine("Opção invalida!");
                                break;
                            }

                            Console.Write("Digite o valor por hora: ");
                            string? salario = Console.ReadLine();
                            decimal valorSalario = 0;

                            if (decimal.TryParse(salario.Replace(",", "."), out valorSalario))
                                cadastroPJ.ValorHora = valorSalario;
                            else
                                Console.WriteLine("Valor invalido!");

                            Console.Write("Digite a quantidade de horas: ");
                            cadastroPJ.QuantidadeHoras = int.Parse(Console.ReadLine());

                            Console.Write("Digite o CNPJ: ");
                            cadastroPJ.CNPJ = Console.ReadLine();

                            listaFuncionariosPJ.Add(cadastroPJ);
                            Console.WriteLine("Cadatro finalizado");
                            break;
                        }
                    case "3":
                        {
                            encerrar = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção invalida!");
                            break;
                        }
                }
                break;
            }
        case "2":
            {
                Console.WriteLine("\n1 - Exibir dados de todos os funcionarios PJ");
                Console.WriteLine("2 - Exibir dados de todos os funcionarios CTL");
                Console.WriteLine("3 - Exibir custo mensal de todos os funcionarios");
                Console.WriteLine("4 - Consultar funcionario por registro para mostrar todos os dados");
                Console.WriteLine("5 - Consultar funcionario por registro para mostrar o custo mensal");
                Console.WriteLine("6 - Sair");
                Console.Write("Digite a sua opção: ");
                string? opcaoConsulta = Console.ReadLine();

                switch (opcaoConsulta)
                {
                    case "1":
                        {
                            foreach (FuncionarioPJ funcionarioPJ in listaFuncionariosPJ)
                            {
                                Console.WriteLine(funcionarioPJ);
                            }
                            break;
                        }
                    case "2":
                        {
                            foreach (FuncionarioCLT funcionarioCLT in listaFuncionariosCLT)
                            {
                                Console.WriteLine(funcionarioCLT);
                            }
                            break;
                        }
                    case "3":
                        {
                            decimal valorTotal = 0;
                            foreach (FuncionarioCLT funcionarioCLT in listaFuncionariosCLT)
                            {
                                valorTotal += funcionarioCLT.CustoMensalCLT();
                            }
                            foreach (FuncionarioPJ funcionarioPJ in listaFuncionariosPJ)
                            {
                                valorTotal += funcionarioPJ.CustoMensalPJ();
                            }
                            Console.WriteLine($"Custo total dos funcionarios R$: {Math.Round(valorTotal,2)}");
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Digite o registro: ");
                            int registro = int.Parse(Console.ReadLine());
                            FuncionarioPJ? funcionarioPJ = listaFuncionariosPJ.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);

                            if (funcionarioPJ != null)
                                Console.WriteLine(funcionarioPJ);
                            else
                            {
                                FuncionarioCLT? funcionarioCLT = listaFuncionariosCLT.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);
                                if(funcionarioCLT != null)
                                    Console.WriteLine(funcionarioCLT);
                                else
                                    Console.WriteLine("Funcionario não encontrado!");
                            } 
                            break;
                        }
                    case "5":
                        {
                            Console.Write("Digite o registro: ");
                            int registro = int.Parse(Console.ReadLine());
                            FuncionarioPJ? funcionarioPJ = listaFuncionariosPJ.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);

                            if (funcionarioPJ != null)
                            {
                                try
                                {

                                    Console.Write("O Funcionario fez horas extras? <S> para Sim e <N> para Não: ");
                                    string isHoraExtra = Console.ReadLine();
                                    if (isHoraExtra.ToUpper() == "S")
                                    {
                                        Console.WriteLine("Digite a quantidade de horas extras: ");
                                        int horaExtra = int.Parse(Console.ReadLine());
                                        Console.WriteLine($"O custo mensal com hora extra, do usuario {funcionarioPJ.Nome} é: {Math.Round(funcionarioPJ.CustoMensalPJ(horaExtra), 2)}");
                                    }
                                    else if (isHoraExtra.ToUpper() == "N")
                                    {
                                        Console.WriteLine($"O custo mensal do usuario {funcionarioPJ.Nome} é: {Math.Round(funcionarioPJ.CustoMensalPJ(), 2)}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opção invalida!");
                                    }

                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            }
                            else
                            {
                                FuncionarioCLT? funcionarioCLT = listaFuncionariosCLT.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);
                                if (funcionarioCLT != null)
                                    Console.WriteLine($"O custo mensal do usuario {funcionarioCLT.Nome} é: {Math.Round(funcionarioCLT.CustoMensalCLT(), 2)}");
                                else
                                    Console.WriteLine("Funcionario não encontrado!");

                            }
                            break;
                        }
                    case "6":
                        {
                            encerrar = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção invalida!");
                            break;
                        }
                }
                break;
            }
        case "3":
            {
                Console.WriteLine("\n1 - Aumentar salario do funcionario CLT em % do salario atual");
                Console.WriteLine("2 - Aumentar valor por hora do funcionario PJ");
                Console.WriteLine("3 - Sair");
                Console.Write("Digite a sua opção: ");
                string? opcaoConsulta = Console.ReadLine();

                switch (opcaoConsulta)
                {
                    case "1":
                        {
                            Console.Write("Digite o registro do funcionario: ");
                            int registro = int.Parse(Console.ReadLine());
                            FuncionarioCLT? funcionarioCLT = listaFuncionariosCLT.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);

                            if (funcionarioCLT != null)
                            {
                                Console.Write("Digite o percentual para o aumento do salario: ");
                                decimal percentualAumento = decimal.Parse(Console.ReadLine());
                                if (percentualAumento >= 0)                                
                                    funcionarioCLT.Salario += funcionarioCLT.Salario * (percentualAumento / 100);                                
                                else                                
                                    Console.WriteLine("A porcentagem de aumento não pode ser em valores negativos");                                
                            }
                            else
                            {
                                Console.WriteLine("Funcionario não encontrado!");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Digite o registro do funcionario: ");
                            int registro = int.Parse(Console.ReadLine());
                            FuncionarioPJ? funcionarioPJ = listaFuncionariosPJ.FirstOrDefault(funcionario => funcionario.CodigoRegistro == registro);

                            if (funcionarioPJ != null)
                            {
                                Console.Write("Digite o valor para aumentar o valor por hora: ");
                                int aumentoHora = int.Parse(Console.ReadLine());
                                if (aumentoHora >= 0)                                
                                    funcionarioPJ.ValorHora += aumentoHora;                                
                                else                                
                                    Console.WriteLine("O aumento em reais não pode ser um valor negativo.");                                
                            }
                            else
                            {
                                Console.WriteLine("Funcionario não encontrado!");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção invalida!");
                            break;
                        }
                }
                break;
            }
        case "4":
            {
                Console.WriteLine("Encerrando...");
                encerrar = true;
                break;
            }
        default:
            {
                Console.WriteLine("Opção invalida!");
                break;
            }
    }
}