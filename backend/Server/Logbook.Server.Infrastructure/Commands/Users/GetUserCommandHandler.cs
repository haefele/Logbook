﻿using System;
using System.Threading.Tasks;
using LiteGuard;
using Logbook.Server.Contracts.Commands;
using Logbook.Server.Contracts.Commands.Users;
using Logbook.Shared.Entities.Authentication;

namespace Logbook.Server.Infrastructure.Commands.Users
{
    public class GetUserCommandHandler : ICommandHandler<GetUserCommand, User>
    {
        //private readonly IAsyncDocumentSession _documentSession;

        //public GetUserCommandHandler(IAsyncDocumentSession documentSession)
        //{
        //    Guard.AgainstNullArgument(nameof(documentSession), documentSession);

        //    this._documentSession = documentSession;
        //}

        public Task<User> Execute(GetUserCommand command, ICommandScope scope)
        {
            throw new NotImplementedException();
            //return this._documentSession.LoadAsync<User>(command.UserId);
        }
    }
}