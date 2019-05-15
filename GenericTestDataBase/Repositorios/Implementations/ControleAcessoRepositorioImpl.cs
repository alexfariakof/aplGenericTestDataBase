using GenericTestDataBase.Models;
using GenericTestDataBase.Models.Context;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;

namespace GenericTestDataBase.Repositorio.Implementations
{
    public class ControleAcessoRepositorioImpl : IControleAcessoRepositorio
    {
        private readonly MsSqlContext _context;

        public ControleAcessoRepositorioImpl()
        {
            _context = new MsSqlContext();
        }

        public bool Create(Usuario usuario, ControleAcesso controleAcesso)
        {
            DbSet<Usuario> dsUsuario = null;

            using (_context)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        dsUsuario = _context.Set<Usuario>();                        
                        dsUsuario.Add(usuario);

                        _context.SaveChanges();

                        string sql = "INSERT INTO[dbo].[ControleAcesso] ([login], [senha], [idUsuario]) VALUES (@login, @senha, @idUsuario)";
                        _context.Database.ExecuteSqlCommand(sql, new SqlParameter("@login", controleAcesso.Login), new SqlParameter("@senha", controleAcesso.Senha), new SqlParameter("@idUsuario", usuario.Id.Value));

                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }

            }
            return false;
        }

        public ControleAcesso FindByLogin(string login)
        {
            try
            {
              return  _context.ControleAcessoTB.SingleOrDefault(prop => prop.Login.Equals(login));
            }
            catch
            {
                throw;
            }
        }

        public Usuario GetUsuarioByLogin(string login)
        {
            Usuario usuario = null;
            try
            {
                usuario = _context.UsuarioTB.SingleOrDefault(prop => prop.Email.Equals(login));
                if (usuario == null)
                    usuario = _context.UsuarioTB.SingleOrDefault(prop => prop.Telefone.Equals(login));

                return usuario; // Usuario = null nenhum usuario encontrado 
            }
            catch
            {
                throw;
            }
        }

        public bool RecoveryPassword(string email)
        {
            Usuario usuario = GetUsuarioByLogin(email);
            if (usuario == null)
                return false;

            using (_context)
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {

                        string sql = "UPDATE ControleAcesso SET senha = @senha WHERE login = @login";

                        var senhaNova = Guid.NewGuid().ToString().Substring(0,8);

                        _context.Database.ExecuteSqlCommand(sql, new SqlParameter("@senha", senhaNova), new SqlParameter("@login", usuario.Email));

                        EnviarEmail(usuario, "<b>Nova senha:</b>" + senhaNova);
                        
                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            return false;
        }

        private void EnviarEmail(Usuario usuario, String message)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("appdespesaspessoais@gmail.com", "roottoor");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("appdespesaspessoais@gmail.com", "App Despesas Pessoais");
            mail.From = new MailAddress("appdespesaspessoais@gmail.com", "App Despesas Pessoais");
            mail.To.Add(new MailAddress(usuario.Email, usuario.Nome + " " + usuario.SobreNome));
            mail.Subject = "Contato";
            mail.Body = " Mensagem do site:<br/> Prezado(a)   " + usuario.Nome + " " + usuario.SobreNome + "<br/>Segue dados para acesso a conta cadastrada.<br><b>E-mail:</b> " + usuario.Email + " <br/> " + message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                //client.Send(mail);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                mail = null;
            }
        }
    }
}
