using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente._4j
{
    class Program
    {
        static void Main(string[] args)
        {
            Banca Generali = new Banca("Generali", "via Mameli 12");
            Persona Paolo=new Persona("Paolo", "Rossi", "via Garibaldi 23", "3245698450", "paolorossi@gmail.com", new DateTime (1978,05,13, 12, 45, 00));
            Persona Luca = new Persona("Luca", "Bianchi", "via Mazzini 24", "3390890678", "lucabianchi@gmail.com", new DateTime(1980,08,10,04,05,20));
            Persona Ciccio = new Persona("Ciccio", "Caputo", "Via col vento", "3273936249", "cicciocaputo@gmail.com", new DateTime(2001,03,09,09,03,01));
            Persona personacreata = new Persona("", "", "", "", "", new DateTime(0000/01/01));
            ContoCorrente contocreato = new ContoCorrente(personacreata, 0, 50, 0.0, "IT88A030901651000050560130");
            Conto_Online ContoCreatoOnline = new Conto_Online(50.00, personacreata, 0, 50, 0.0, "IT88A030901651000050570170", "", "");
            ContoCorrente ContoPaolo =new ContoCorrente(Paolo,0,50,200000.00,"IT88A030901651000050570131");
            ContoCorrente ContoCiccio = new ContoCorrente(Ciccio, 0, 50, 300000, "IT88A030901651000050570132");          
            Generali.listaconti.Add(ContoPaolo);
            Conto_Online ContoLucaOnline = new Conto_Online(1000.00, Luca, 0, 50, 10000, "IT88A030901651000050570130", "CiccioCaputo", "Ciccio123");
            Generali.listaconti.Add(ContoLucaOnline);
            ContoCorrente contocercato = new ContoCorrente(personacreata,0,50, 0.0, "IT88A030801651000050570132");
            Console.WriteLine("Persone: \n--" + Paolo.Nome + " " + Paolo.Cognome + "\t Indirizzo: " + Paolo.Indirizzo + "\t Numero di telefono: " + Paolo.NumeroTel + "\t E-Mail: " + Paolo.EMail + "\t Data di nascita: " + Paolo.DataNascita);
            Console.WriteLine("--"+Luca.Nome + " " + Luca.Cognome + "\t Indirizzo: " + Luca.Indirizzo + "\t Numero di telefono: " + Luca.NumeroTel + "\t E-Mail: " + Luca.EMail + "\t Data di nascita: " + Luca.DataNascita);
            Console.WriteLine("--" + Ciccio.Nome + " " + Ciccio.Cognome + "\t Indirizzo: " + Ciccio.Indirizzo + "\t Numero di telefono: " + Ciccio.NumeroTel + "\t E-Mail: " + Ciccio.EMail + "\t Data di nascita: " + Ciccio.DataNascita);
            Console.WriteLine("\nBanca:\n--" + Generali.Nome + "\t" + Generali.Indirizzo);
            Console.WriteLine("\nConti correnti:\n--" + ContoPaolo.IntestatarioConto.Nome + " " + ContoPaolo.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoPaolo.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoPaolo.NMovimenti + "\t IBAN: " + ContoPaolo.Iban+"\t Saldo: "+ContoPaolo.Saldo);
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            Console.WriteLine("\nConti correnti online:\n--" + ContoLucaOnline.IntestatarioConto.Nome + " " + ContoLucaOnline.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoLucaOnline.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoLucaOnline.NMovimenti + "\t IBAN: " + ContoLucaOnline.Iban +"\t Saldo: " + ContoLucaOnline.Saldo);
            Console.WriteLine("\nLista di concorrenti della banca Generali: ");           
            for (int i = 0; i < Generali.listaconti.Count; i++)
            {
                Console.WriteLine("--" + Generali.listaconti[i].IntestatarioConto.Nome + " " + Generali.listaconti[i].IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + Generali.listaconti[i].MaxMovimenti + "\t Numero movimenti effettuati: " + Generali.listaconti[i].NMovimenti+ "\t IBAN: " + Generali.listaconti[i].Iban + "\t Saldo: " + Generali.listaconti[i].Saldo);
            }
            Bonifico bonifico = new Bonifico(ContoCiccio, new DateTime(2020 / 05 / 22), 200, ContoPaolo);
            bonifico.CreaBonifico(ContoCiccio, new DateTime(2020 / 05 / 22), 200, ContoPaolo);
            Console.WriteLine("\n\n\nMovimenti: \n");
            Console.WriteLine("\nSi effettua un bonifico da 200 euro dal conto di Paolo Rossi al conto di Ciccio Caputo, i nuovi dati dei conti saranno:");
            Console.WriteLine("--" + ContoPaolo.IntestatarioConto.Nome + " " + ContoPaolo.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoPaolo.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoPaolo.NMovimenti + "\t IBAN: " + ContoPaolo.Iban + "\t Saldo: " + ContoPaolo.Saldo);
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            Versamento versamento = new Versamento(new DateTime(2020, 05, 22, 22, 05, 20), 40, ContoLucaOnline);
            versamento.CreaVersamento();
            Console.WriteLine("\nLuca effettura un versamento da 40 euro sul proprio conto online, i nuovi dati del suo conto saranno:");
            Console.WriteLine("--" + ContoLucaOnline.IntestatarioConto.Nome + " " + ContoLucaOnline.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoLucaOnline.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoLucaOnline.NMovimenti + "\t IBAN: " + ContoLucaOnline.Iban + "\t Saldo: " + ContoLucaOnline.Saldo);
            Prelievo prelievo = new Prelievo(new DateTime(2020, 05, 22, 22, 05, 20), 200, ContoCiccio);
            prelievo.CreaPrelievo();
            Console.WriteLine("\nCicco Caputo preleva i soldi ricevuti dal bonifico effettuato da Paolo, i dati del suo conto saranno aggiornati a:");
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            int scelta1=1;
            int altro = 0;
            List<int> scelte = new List<int>();
            do {
                do {
                    Console.WriteLine("\nCosa vuoi aggiungere? \n 1- aggiungi conto \n 2- aggiungi conto online \n 3- aggiungi banca \n 4- aggiungi movimento \n 5- aggiungi intestatario \n 6- non aggiungere niente\n INSERISCI UN NUMERO COMPRESO TRA 1 E 6");
                    scelta1 = Convert.ToInt32(Console.ReadLine());
                } while (scelta1 > 6 || scelta1 < 1);
                string npersonaricerca = "";
                string cpersonaricerca = "";
                Persona personaricerca = null;
                bool successo = false;
                bool sovrascrivi = false;
                int sceltasovrascrivi = 0;
                if (scelta1 == 1) {
                    Console.WriteLine("\nInserisci il nome dell'intestatario:");
                    npersonaricerca = Console.ReadLine();
                    Console.WriteLine("Inserisci il cognome dell'intestatario:");
                    cpersonaricerca = Console.ReadLine();
                    if (Paolo.Nome == npersonaricerca)
                    {
                        if (Paolo.Cognome == cpersonaricerca)
                        {
                            personaricerca = Paolo;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (Luca.Nome == npersonaricerca)
                    {
                        if (Luca.Cognome == cpersonaricerca)
                        {
                            personaricerca = Luca;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (Ciccio.Nome == npersonaricerca)
                    {
                        if (Ciccio.Cognome == cpersonaricerca)
                        {
                            personaricerca = Ciccio;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (personacreata.Nome == npersonaricerca)
                    {
                        if (personacreata.Cognome == cpersonaricerca)
                        {
                            personaricerca = personacreata;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (successo == false)
                    {
                        Console.WriteLine("\nPersona non presente nel database. \noperazione annullata.");
                    }
                    if (successo == true)
                    {
                        contocreato.IntestatarioConto = personaricerca;
                        Console.WriteLine("\nConto creato con successo.");
                        scelte.Add(scelta1);
                    }
                    do
                    {
                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                        altro = Convert.ToInt32(Console.ReadLine());
                    } while (altro<1||altro>2);
                }
                string usernameutente = "";
                string passwordutente = "";
                if (scelta1 == 2) {
                    Console.WriteLine("\nInserisci il nome dell'intestatario:");
                    npersonaricerca = Console.ReadLine();
                    Console.WriteLine("Inserisci il cognome dell'intestatario:");
                    cpersonaricerca = Console.ReadLine();
                    if (Paolo.Nome == npersonaricerca)
                    {
                        if (Paolo.Cognome == cpersonaricerca)
                        {
                            personaricerca = Paolo;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (Luca.Nome == npersonaricerca)
                    {
                        if (Luca.Cognome == cpersonaricerca)
                        {
                            personaricerca = Luca;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (Ciccio.Nome == npersonaricerca)
                    {
                        if (Ciccio.Cognome == cpersonaricerca)
                        {
                            personaricerca = Ciccio;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (personacreata.Nome == npersonaricerca)
                    {
                        if (personacreata.Cognome == cpersonaricerca)
                        {
                            personaricerca = personacreata;
                            successo = true;
                            Console.WriteLine("\nPersona trovata nel database");
                        }
                    }
                    if (successo == false)
                    {
                        Console.WriteLine("\nPersona non presente nel database. \noperazione annullata.");
                        do
                        {
                            Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                            altro = Convert.ToInt32(Console.ReadLine());
                        } while (altro < 1 || altro > 2);
                    }
                    if (successo == true)
                    {
                        Console.WriteLine("\nInserisci l'username dell'utente:");
                        usernameutente = Console.ReadLine();
                        Console.WriteLine("Inserisci la password dell'utente:");
                        passwordutente = Console.ReadLine();
                        ContoCreatoOnline.IntestatarioConto = personaricerca;
                        ContoCreatoOnline.Username = usernameutente;
                        ContoCreatoOnline.Password = passwordutente;
                        Console.WriteLine("\nConto creato con successo.");
                        scelte.Add(scelta1);
                        do
                        {
                            Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                            altro = Convert.ToInt32(Console.ReadLine());
                        } while (altro < 1 || altro > 2);
                    }
                }
                string nomebanca = "";
                string indirizzobanca = "";
                if (scelta1 == 3) {
                    for (int i = 0; i < scelte.Count; i++)
                    {
                        if (scelte[i] == 3)
                        {
                            sovrascrivi = true;
                        }
                    }
                    if (sovrascrivi == true)
                    {
                        Console.WriteLine("E' stato creato il numero massimo delle banche, sovrascrivere la precedente?\n1- si\n2- no");
                        sceltasovrascrivi = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("\nInserisci il nome della banca:");
                        nomebanca = Console.ReadLine();
                        Console.WriteLine("Inserisci l'indirizzo della banca:");
                        indirizzobanca = Console.ReadLine();
                        Banca bancacreata = new Banca(nomebanca, indirizzobanca);
                        Console.WriteLine("\nBanca creata con successo");
                        scelte.Add(scelta1);
                    }
                    if (sceltasovrascrivi == 1)
                    {
                        Console.WriteLine("\nInserisci il nome della banca:");
                        nomebanca = Console.ReadLine();
                        Console.WriteLine("Inserisci l'indirizzo della banca:");
                        indirizzobanca = Console.ReadLine();
                        Banca bancacreata = new Banca(nomebanca, indirizzobanca);
                        Console.WriteLine("\nBanca creata con successo");
                        scelte.Add(scelta1);
                    }
                    if (sceltasovrascrivi == 2)
                    {
                        Console.WriteLine("Operazione anullata");
                    }
                    do
                    {
                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                        altro = Convert.ToInt32(Console.ReadLine());
                    } while (altro < 1 || altro > 2);
                }
                double importo = 0;
                if (scelta1 == 4) {
                    int Contatoremov = 0;
                    int sceltamov = 0;
                    do {
                        if (Contatoremov >= 1) {
                            Console.WriteLine("Inserisci un numero compreso tra 1 e 3");
                        }
                        Console.WriteLine("\nquale movimento vuoi aggiungere? \n 1- aggiungi versamento \n 2- aggiungi prelievo \n 3- aggiungi bonifico");
                        sceltamov = Convert.ToInt32(Console.ReadLine());
                        Contatoremov++;
                    } while (sceltamov < 1 || sceltamov > 3);
                    if (sceltamov == 1) {
                        Console.WriteLine("\nVERSAMENTO:\nnome intestatario del conto:");
                        npersonaricerca = Console.ReadLine();
                        Console.WriteLine("cognome intestatario conto:");
                        cpersonaricerca = Console.ReadLine();
                        if (ContoPaolo.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoPaolo.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoPaolo;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCiccio.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCiccio.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCiccio;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoLucaOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoLucaOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoLucaOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = contocreato;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = contocreato;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCreatoOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCreatoOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCreatoOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (successo == false)
                        {
                            Console.WriteLine("\nConto non trovato nel database.\nOperazione annullata.");
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                        if (successo == true)
                        {
                            Console.WriteLine("inserisci l'importo del movimento:");
                            importo = Convert.ToDouble(Console.ReadLine());
                            contocercato.Saldo = contocercato.Saldo + importo;
                            Console.WriteLine("Versamento effettuato con successo.");
                            scelte.Add(scelta1);
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                    }
                    if (sceltamov == 2) {
                        Console.WriteLine("\nPRELIEVO:\nnome intestatario del conto:");
                        npersonaricerca = Console.ReadLine();
                        Console.WriteLine("cognome intestatario conto:");
                        cpersonaricerca = Console.ReadLine();
                        if (ContoPaolo.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoPaolo.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoPaolo;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCiccio.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCiccio.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCiccio;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoLucaOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoLucaOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoLucaOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = contocreato;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = contocreato;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCreatoOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCreatoOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCreatoOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (successo == false)
                        {
                            Console.WriteLine("\nConto non trovato nel database.\nOperazione annullata.");
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                        if (successo == true)
                        {
                            contocercato.Saldo = contocercato.Saldo - importo;
                            Console.WriteLine("Prelievo effettuato con successo.");
                            scelte.Add(scelta1);
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                    }
                    if (sceltamov == 3) {
                        Console.WriteLine("\nBONIFICO:\nnome intestatario del conto (mittente):");
                        npersonaricerca = Console.ReadLine();
                        Console.WriteLine("cognome intestatario conto:");
                        cpersonaricerca = Console.ReadLine();
                        if (ContoPaolo.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoPaolo.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoPaolo;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCiccio.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCiccio.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCiccio;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoLucaOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoLucaOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoLucaOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = contocreato;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (ContoCreatoOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCreatoOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                successo = true;
                                contocercato = ContoCreatoOnline;
                                Console.WriteLine("\nConto trovato nel database.");
                            }
                        }
                        if (successo == false)
                        {
                            Console.WriteLine("\nConto non trovato nel database.\nOperazione annullata.");
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                        if (successo == true)
                        {
                            Console.WriteLine("inserisci l'importo del movimento:");
                            importo = Convert.ToDouble(Console.ReadLine());
                            contocercato.Saldo = contocercato.Saldo - importo;
                            successo = false;
                        }
                        bool ripetizione = false;
                        Console.WriteLine("\nnome intestatario del conto (destinatario):");
                        npersonaricerca = Console.ReadLine();
                        Console.WriteLine("cognome intestatario conto:");
                        cpersonaricerca = Console.ReadLine();
                        if (ContoPaolo.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoPaolo.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                if (ContoPaolo == contocercato)
                                {
                                    successo = false;
                                    ripetizione = true;
                                    Console.WriteLine("E' stato selezionato lo stesso conto selezionato precedentemente, non è possibile eseguire il bonifico. \nOperazione annullata.");
                                    do
                                    {
                                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                        altro = Convert.ToInt32(Console.ReadLine());
                                    } while (altro < 1 || altro > 2);
                                }
                                else
                                {
                                    successo = true;
                                    contocercato = ContoPaolo;
                                    Console.WriteLine("\nConto trovato nel database.");
                                }
                            }
                        }
                        if (ContoCiccio.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCiccio.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                if (ContoCiccio == contocercato)
                                {
                                    successo = false;
                                    ripetizione = true;
                                    Console.WriteLine("E' stato selezionato lo stesso conto selezionato precedentemente, non è possibile eseguire il bonifico. \nOperazione annullata.");
                                    do
                                    {
                                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                        altro = Convert.ToInt32(Console.ReadLine());
                                    } while (altro < 1 || altro > 2);
                                }
                                else
                                {
                                    successo = true;
                                    contocercato = ContoCiccio;
                                    Console.WriteLine("\nConto trovato nel database.");
                                }
                            }
                        }
                        if (ContoLucaOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoLucaOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                if (ContoLucaOnline == contocercato)
                                {
                                    successo = false;
                                    ripetizione = true;
                                    Console.WriteLine("E' stato selezionato lo stesso conto selezionato precedentemente, non è possibile eseguire il bonifico. \nOperazione annullata.");
                                    do
                                    {
                                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                        altro = Convert.ToInt32(Console.ReadLine());
                                    } while (altro < 1 || altro > 2);
                                }
                                else
                                {
                                    successo = true;
                                    contocercato = ContoLucaOnline;
                                    Console.WriteLine("\nConto trovato nel database.");
                                }
                            }
                        }
                        if (contocreato.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (contocreato.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                if (contocreato == contocercato)
                                {
                                    successo = false; ripetizione = true;
                                    Console.WriteLine("E' stato selezionato lo stesso conto selezionato precedentemente, non è possibile eseguire il bonifico. \nOperazione annullata.");
                                    do
                                    {
                                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                        altro = Convert.ToInt32(Console.ReadLine());
                                    } while (altro < 1 || altro > 2);
                                }
                                else
                                {
                                    successo = true;
                                    contocercato = contocreato;
                                    Console.WriteLine("\nConto trovato nel database.");
                                }
                            }
                        }
                        if (ContoCreatoOnline.IntestatarioConto.Nome == npersonaricerca)
                        {
                            if (ContoCreatoOnline.IntestatarioConto.Cognome == cpersonaricerca)
                            {
                                if (ContoCreatoOnline == contocercato)
                                {
                                    successo = false;
                                    ripetizione = true;
                                    Console.WriteLine("E' stato selezionato lo stesso conto selezionato precedentemente, non è possibile eseguire il bonifico. \nOperazione annullata.");
                                    do
                                    {
                                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                        altro = Convert.ToInt32(Console.ReadLine());
                                    } while (altro < 1 || altro > 2);
                                }
                                else
                                {
                                    successo = true;
                                    contocercato = ContoCreatoOnline;
                                    Console.WriteLine("\nConto trovato nel database.");
                                }
                            }
                        }
                        if (successo == false && ripetizione == false)
                        {
                            Console.WriteLine("\nConto non trovato nel database.\nOperazione annullata.");
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                        if (successo == true)
                        {
                            contocercato.Saldo = contocercato.Saldo - importo;
                            Console.WriteLine("Bonifico effettuato con successo.");
                            scelte.Add(scelta1);
                            do
                            {
                                Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                                altro = Convert.ToInt32(Console.ReadLine());
                            } while (altro < 1 || altro > 2);
                        }
                    }
                }
                if (scelta1 == 5) {
                    for (int i = 0; i < scelte.Count; i++)
                    {
                        if (scelte[i] == 5)
                        {
                            sovrascrivi = true;
                        }
                    }
                    if (sovrascrivi == true)
                    {
                        Console.WriteLine("E' stato creato il numero massimo degli intestatari, sovrascrivere la precedente?\n1- si\n2- no");
                        sceltasovrascrivi = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        string nomepersona = "";
                        string cognomepersona = "";
                        string emailpersona = "";
                        string numeropersona = "";
                        string indirizzopersona = "";
                        int annonascitapersona = 0;
                        int mesenascitapersona = 0;
                        int giornonascitapersona = 0;
                        Console.WriteLine("\nInserisci il nome della persona:");
                        nomepersona = Console.ReadLine();
                        personacreata.Nome = nomepersona;
                        Console.WriteLine("Inserisci il cognome della persona:");
                        cognomepersona = Console.ReadLine();
                        personacreata.Cognome = cognomepersona;
                        Console.WriteLine("Inserisci l'idirizzo della persona:");
                        indirizzopersona = Console.ReadLine();
                        personacreata.Indirizzo = indirizzopersona;
                        Console.WriteLine("Inserisci il numero di telefono della persona:");
                        numeropersona = Console.ReadLine();
                        personacreata.NumeroTel = numeropersona;
                        Console.WriteLine("Inserisci l' e-mail della persona:");
                        emailpersona = Console.ReadLine();
                        personacreata.EMail = emailpersona;
                        Console.WriteLine("Inserisci l'anno di nascita della persona:");
                        annonascitapersona = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Inserisci il mese di nascita della persona:");
                        mesenascitapersona = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Inserisci il giorno di nascita della persona:");
                        giornonascitapersona = Convert.ToInt32(Console.ReadLine());
                        personacreata.DataNascita = new DateTime(annonascitapersona / mesenascitapersona / giornonascitapersona);
                        Console.WriteLine("\nPersona creata con successo.");
                        scelte.Add(scelta1);
                    }
                    if (sceltasovrascrivi == 1)
                    {
                        string nomepersona = "";
                        string cognomepersona = "";
                        string emailpersona = "";
                        string numeropersona = "";
                        string indirizzopersona = "";
                        int annonascitapersona = 0;
                        int mesenascitapersona = 0;
                        int giornonascitapersona = 0;
                        Console.WriteLine("\nInserisci il nome della persona:");
                        nomepersona = Console.ReadLine();
                        personacreata.Nome = nomepersona;
                        Console.WriteLine("Inserisci il cognome della persona:");
                        cognomepersona = Console.ReadLine();
                        personacreata.Cognome = cognomepersona;
                        Console.WriteLine("Inserisci l'idirizzo della persona:");
                        indirizzopersona = Console.ReadLine();
                        personacreata.Indirizzo = indirizzopersona;
                        Console.WriteLine("Inserisci il numero di telefono della persona:");
                        numeropersona = Console.ReadLine();
                        personacreata.NumeroTel = numeropersona;
                        Console.WriteLine("Inserisci l' e-mail della persona:");
                        emailpersona = Console.ReadLine();
                        personacreata.EMail = emailpersona;
                        Console.WriteLine("Inserisci l'anno di nascita della persona:");
                        annonascitapersona = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Inserisci il mese di nascita della persona:");
                        mesenascitapersona = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Inserisci il giorno di nascita della persona:");
                        giornonascitapersona = Convert.ToInt32(Console.ReadLine());
                        personacreata.DataNascita = new DateTime(annonascitapersona / mesenascitapersona / giornonascitapersona);
                        Console.WriteLine("\nPersona creata con successo.");
                        scelte.Add(scelta1);
                    }
                    if (sceltasovrascrivi == 2)
                    {
                        Console.WriteLine("Operazione anullata");
                    }
                    do
                    {
                        Console.WriteLine("\n Aggiungere altro?\n1- si\n2- no");
                        altro = Convert.ToInt32(Console.ReadLine());
                    } while (altro < 1 || altro > 2);
                }
            } while (altro==1);
            Console.ReadLine();
        }
    }
}