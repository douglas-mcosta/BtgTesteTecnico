﻿using BTG.Core.Messages;
using FluentValidation.Results;

namespace BTG.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
        Task PublishEvent<T>(T evento) where T : Event;
    }
}
