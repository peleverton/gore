﻿using MediatR;
using System;

namespace Gore.Domain.Core.Events
{
    public abstract class Message : IRequest
    {
        public string MessageType { get; protected set; }
        public int AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
