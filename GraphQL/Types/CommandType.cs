using System.Linq;
using System.Threading.Tasks;
using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL.Types
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform");

            descriptor.Field("flags")
                .ResolveWith<Resolvers>(c => c.GetFlags(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("yes i am");
        }

        private class Resolvers
        {
            public async Task<Platform> GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                var response = await context.Platforms.FirstOrDefaultAsync(p => p.Id == command.PlatformId);
                return response;
            }

            public IQueryable<Flag> GetFlags(Command command, [ScopedService] AppDbContext context)
            {
                return context.Flags
                    .Where(flag => flag.CommandHasFlags.Any(x => x.CommandId == command.Id));
            }
        }
    }
}