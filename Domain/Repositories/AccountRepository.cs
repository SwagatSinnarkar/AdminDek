using Dapper;
using Domain.Models;
using Domain.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Domain.Repositories
{
    public class AccountRepository
    {
        private readonly string connectionString;
        private readonly ConnectionRepository _connRepository;

        public AccountRepository()
        {
            _connRepository = new ConnectionRepository();
            var conn = _connRepository.GetConnection();
            this.connectionString = conn;
        }

        //Regsiter
        public int SaveAdminData(AccountModel _accountModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var param = new DynamicParameters();
                        param.Add("@Id", _accountModel.Id);
                        param.Add("@Email", _accountModel.Email);
                        param.Add("@EmailConfirmed", _accountModel.EmailConfirmed);
                        param.Add("@PasswordHash", _accountModel.PasswordHash);
                        param.Add("@SecurityStamp", _accountModel.SecurityStamp);
                        param.Add("@PhoneNumber", _accountModel.PhoneNumber);
                        param.Add("@PhoneNumberConfirmed", _accountModel.PhoneNumberConfirmed);
                        param.Add("@TwoFactorEnabled", _accountModel.TwoFactorEnabled);
                        param.Add("@LockoutEndDateUtc", _accountModel.LockoutEndDateUtc);
                        param.Add("@LockoutEnabled", _accountModel.LockoutEnabled);
                        param.Add("@AccessFailedCount", _accountModel.AccessFailedCount);
                        param.Add("@UserName", _accountModel.UserName);
                        var id = connection.Query<int>("SaveAdminData", param, commandType: CommandType.StoredProcedure, transaction: tran).Single();
                        tran.Commit();
                        return id;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }

        //Update Admin
        public int UpdateAdminData(AccountModel _accountModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var param = new DynamicParameters();
                        param.Add("@AccountId", _accountModel.AccountId);
                        param.Add("@Id", _accountModel.Id);
                        param.Add("@Email", _accountModel.Email);
                        param.Add("@Mobile", _accountModel.Mobile);
                        param.Add("@City", _accountModel.City);
                        param.Add("@State", _accountModel.State);
                        param.Add("@Country", _accountModel.Country);
                        param.Add("@ImageName", _accountModel.ImageName);
                        param.Add("@ImageByte", _accountModel.ImageByte);
                        param.Add("@ImagePath", _accountModel.ImagePath);
                        var id = connection.Query<int>("UpdateAdminData", param, commandType: CommandType.StoredProcedure, transaction: tran).SingleOrDefault();
                        tran.Commit();
                        return id;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }


        //Get Admin
        public IEnumerable<AccountModel> GetAdminUserData(string tableName, string Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                return connection.Query<AccountModel>(string.Format("SELECT * from {0} where Id='{1}'", tableName, Id)).ToList();
        }


        //GetUserIdOnEmail
        public AccountModel GetUserIdOnEmail(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
                return connection.Query<AccountModel>(string.Format("select * from UpdateAdminTbl where Email = '{0}'", userEmail)).FirstOrDefault();
        }
    }
}