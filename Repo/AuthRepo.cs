using Microsoft.EntityFrameworkCore;
using Reada_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Repo
{
    public class AuthRepo: IAuthRepo
    {
        private readonly DbEFContext db;
        public AuthRepo(DbEFContext _DB)
        {
            db = _DB;
        }
        public async Task<UsreDto> Login(UsreDto user)
        {

            var userfind = await db.User.FirstOrDefaultAsync(a => a.Username == user.Username);

            if (user == null) return null;

            if (!VerifyPassHash(user.Password, userfind.SaltePass, userfind.PassHash)) return null;

            return user;


        }

        private bool VerifyPassHash(string password, byte[] saltePass, byte[] passHash)
        {


            using (var Hmac = new System.Security.Cryptography.HMACSHA512(saltePass))
            {

                var ComputedHashPass = Hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < ComputedHashPass.Length; i++)
                {

                    if (ComputedHashPass[i] != passHash[i]) return false;

                }


                return true;

            }

            throw new NotImplementedException();

        }
    }
}
