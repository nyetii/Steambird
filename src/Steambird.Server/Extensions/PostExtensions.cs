using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Steambird.Server.Dtos;
using Steambird.Server.Models;

namespace Steambird.Server.Extensions;

public static partial class PostExtensions
{
    public static PostDto? ToDto(this Post? post) => post is null ? null : new PostDto(post);

    public static async IAsyncEnumerable<PostDto> ToDto(this IAsyncEnumerable<Post> posts)
    {
        var enumerator = posts.GetAsyncEnumerator();

        while (await enumerator.MoveNextAsync())
            yield return enumerator.Current.ToDto();
        

        await enumerator.DisposeAsync();
    }

    public static string ToYearMonthString(this DateTime value)
    {
        var year = value.Year;
        var month = value.Month;

        return $"{year:D4}-{month:D2}";
    }

    public static string RemoveSpecialCharacters(this string str, string replacement = "")
    {
        return SpecialCharactersRegex().Replace(str, replacement);
    }

    public static string ToSlug(this string str)
    {
        return str.ToLowerInvariant().RemoveSpecialCharacters("-").Trim('-');
    }

    public static void ValidateLength(this string str, uint minLength, uint maxLength)
    {
        if (minLength > maxLength)
            throw new InvalidOperationException("Min Length is larger than Max Length.");

        if (str.Length < minLength || str.Length > maxLength)
            throw new ValidationException("Invalid length.");
    }

    public static void MaxLength(this string str, uint maxLength)
    {
        if (str.Length > maxLength)
            throw new ValidationException($"Max length is {maxLength}");
    }

    [GeneratedRegex("[^a-zA-Z0-9_.]+", RegexOptions.Compiled)]
    private static partial Regex SpecialCharactersRegex();
}