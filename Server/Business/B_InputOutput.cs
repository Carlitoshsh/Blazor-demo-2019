using BlazorTest.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Server.Business
{
    public class B_InputOutput : DefaultConnection
    {
        public async Task<int> CreateInputOutput(InputOutput inputOutput)
        {
            var affectedRows = await Query<InputOutput>("INSERT INTO InputOutput (Id, Date,Quantity ,IsInput ) Values (@Id,@Date,@Quantity ,@IsInput);",
                new
                {
                    inputOutput.Id,
                    inputOutput.Date,
                    inputOutput.Quantity,
                    inputOutput.IsInput
                }
            );

            return affectedRows.Count;
        }

        public async Task UpdateInputOutput(InputOutput inputOutput)
        {
            await Query<InputOutput>("Update InputOutput set Date = @Date, Quantity = @Quantity,  IsInput = @IsInput where Id = @Id;",
                   new
                   {
                       inputOutput.Id,
                       inputOutput.Date,
                       inputOutput.Quantity,
                       inputOutput.IsInput
                   }
               );
        }

        public async Task<List<Category>> InputOutputList()
        {
            return await Query<Category>("select * from InputOutput");
        }
    }
}
