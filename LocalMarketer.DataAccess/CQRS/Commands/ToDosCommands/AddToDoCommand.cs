using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands
{
        public class AddToDoCommand : CommandBase<ToDo, ToDo>
        {
                public override async Task<ToDo> Execute(LocalMarketerDbContext context)
                {
                        await context.ToDos.AddAsync(this.Parameter);
                        await context.SaveChangesAsync();
                        return this.Parameter;
                }
        }
}