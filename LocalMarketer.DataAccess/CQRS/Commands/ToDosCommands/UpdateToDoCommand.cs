using LocalMarketer.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMarketer.DataAccess.CQRS.Commands.ToDosCommands
{
        public class UpdateToDoCommand : CommandBase<ToDo, ToDo>
        {
                public override async Task<ToDo> Execute(LocalMarketerDbContext context)
                {
                        context.ToDos.Update(this.Parameter);

                        context.Entry(this.Parameter)
                                .Property(x => x.DealId).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreationDate).IsModified = false;
                        context.Entry(this.Parameter)
                                .Property(x => x.CreatorId).IsModified = false;

                        await context.SaveChangesAsync();

                        return this.Parameter;
                }
        }
}
