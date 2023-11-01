using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;

namespace MyScriptureJournal.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJournalContext>>()))
        {
            if (context == null || context.Entry == null)
            {
                throw new ArgumentNullException("Null RazorPagesScriptureContext");
            }

            // Look for any scriptures.
            if (context.Entry.Any())
            {
                return;   // DB has been seeded
            }

            context.Entry.AddRange(
                new Entry
                {
                    Title = "Jesus Christ",
                    Notes = "He truly lives",
                    AddedDate = DateTime.Parse("2023-1-11"),
                    Book = "Moroni",
                    Scripture = "07:48"
                },

                new Entry
                {
                    Title = "Anger",
                    Notes = "I fear lest like the Lamanites we may also fall into anger if we do not heaken to the voice of the spirit",
                    AddedDate = DateTime.Parse("2023-11-1"),
                    Book = "Moroni ",
                    Scripture = "09:03"
                },

                new Entry
                {
                    Title = "Oposition in all things",
                    Notes = "There mus needs be opposition in all things",
                    AddedDate = DateTime.Parse("2023-10-26"),
                    Book = "2 Nephi",
                    Scripture = "02:11"
                },

                new Entry
                {
                    Title = "The why of the Book of Mormon",
                    Notes = "It is written for the intent that we may believe in Christ and in the power of our Father in Heaven",
                    AddedDate = DateTime.Parse("2023-10-27"),
                    Book = "Mormon",
                    Scripture = "07:09"
                }
            );
            context.SaveChanges();
        }
    }
}