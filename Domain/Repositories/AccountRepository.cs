﻿using Dapper;
using Domain.Models;
using Domain.Repositories.Connection;
using System;
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
    }
}