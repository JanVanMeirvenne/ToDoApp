using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using ToDoApp.Application.Common.Interfaces;
using ToDoApp.Application.ToDoItems.Commands.CreateToDoItem;

namespace ToDoApp.Application.ToDoUsers.Commands.CreateToDoUser
{
    public class CreateToDoUserCommandValidator:AbstractValidator<CreateToDoUserCommand>
    {
        private readonly ICurrentUserService _currentUser;

        public CreateToDoUserCommandValidator(ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }
        
        public override ValidationResult Validate(ValidationContext<CreateToDoUserCommand> context)
        {
            if (_currentUser.Id.Equals(Guid.Empty) || string.IsNullOrEmpty(_currentUser.Mail) ||
                string.IsNullOrEmpty(_currentUser.Name))
            {
                return new ValidationResult(new List<ValidationFailure>()
                {
                    new ValidationFailure("User","User is empty")
                });
                
            }
            return base.Validate(context);
        }
    }
}