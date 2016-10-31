using System;
using System.Collections.Generic;
using System.Linq;

namespace Raupjc_dz2_zad1
{
        /// <summary >
        /// Class that encapsulates all the logic for accessing TodoTtems .
        /// </summary >
        public class TodoRepository : ITodoRepository
        {
            /// <summary >
            /// Repository does not fetch todoItems from the actual database ,
            /// it uses in memory storage for this excersise .
            /// </summary >
            private readonly List<TodoItem> _inMemoryTodoDatabase;

            public TodoRepository(List<TodoItem> initialDbState = null)
            {
                if (initialDbState != null)
                {
                    _inMemoryTodoDatabase = initialDbState;
                }
                else
                {
                    _inMemoryTodoDatabase = new List<TodoItem>();
                }

                // Shorter way to write this in C# using ?? operator :
                // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >() ;
                // x ?? y -> if x is not null , expression returns x. Else y.
            }


            public TodoItem Get(Guid todoId) //?
            {
                TodoItem result = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId))
                                                       .FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else return null;
            }

            public void Add(TodoItem todoItem)
            {
                if (todoItem == null) throw new ArgumentNullException();
                if (Equals(Get(todoItem.Id), todoItem)) throw new DuplicateTodoItemException();
                
                _inMemoryTodoDatabase.Add(todoItem);
            }

            public bool Remove(Guid todoId)
            {
                TodoItem result = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId))      //?
                                                                    .FirstOrDefault();
                if (result != null)
                {
                    _inMemoryTodoDatabase.Remove(result);
                    return true;
                }
                else return false;
            }

            public void Update(TodoItem todoItem)
            {
                TodoItem result = _inMemoryTodoDatabase.Where(i => i.Equals(todoItem))      //?
                                                                    .FirstOrDefault();

                if (result == null)
                    Add(todoItem);
            }

            public bool MarkAsCompleted(Guid todoId)
            {
                TodoItem result = _inMemoryTodoDatabase.Where(i => i.Id.Equals(todoId))      //?
                                                                      .FirstOrDefault();

                if (result != null)
                {
                    result.IsCompleted = true;
                    result.DateCompleted = DateTime.Now;
                    return true;
                }
                else return false;
            }

            public List<TodoItem> GetAll()
            {
                //IEnumerable<TodoItem>
                List<TodoItem> all = _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated)
                                                          .ToList();

                return all;
            }

            public List<TodoItem> GetActive()
            {
                List<TodoItem> active = _inMemoryTodoDatabase.Where(i => i.IsCompleted == false)
                                                             .ToList();
                return active;
            }

            public List<TodoItem> GetCompleted()
            {
                List<TodoItem> completed = _inMemoryTodoDatabase.Where(i => i.IsCompleted)
                                                             .ToList();
                return completed;
            }

            public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
            {
                List<TodoItem> filtered = _inMemoryTodoDatabase.Where(filterFunction)
                                                               .ToList();
                return filtered;
            }
        }
        // implement ITodoRepository
    }
