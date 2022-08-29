// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class TextTasks
    {
        public static UTF8Encoding UTF8NoBom => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        public static void WriteAllLines(string path, IEnumerable<string> lines, Encoding encoding = null)
        {
            WriteAllLines(path, lines.ToArray(), encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        public static void WriteAllLines(string path, string[] lines, Encoding encoding = null)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllLines(path, lines, encoding ?? UTF8NoBom);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllText)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllText($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllText($args$)",
            Message = $"WARNING: {nameof(WriteAllText)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllText($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllText($args$)",
            Message = $"WARNING: {nameof(WriteAllText)} is obsolete")]
        public static void WriteAllText(string path, string content, Encoding encoding = null)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllText(path, content, encoding ?? UTF8NoBom);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllBytes)} extension method")]
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllBytes(path, bytes);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllText)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllText($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllText($args$)",
            Message = $"WARNING: {nameof(ReadAllText)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllText($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllText($args$)",
            Message = $"WARNING: {nameof(ReadAllText)} is obsolete")]
        public static string ReadAllText(string path, Encoding encoding = null)
        {
            Assert.FileExists(path);
            return File.ReadAllText(path, encoding ?? Encoding.UTF8);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllLines($args$)",
            Message = $"WARNING: {nameof(ReadAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllLines($args$)",
            Message = $"WARNING: {nameof(ReadAllLines)} is obsolete")]
        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            Assert.FileExists(path);
            return File.ReadAllLines(path, encoding ?? Encoding.UTF8);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllBytes)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllBytes($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllBytes($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllBytes($args$)",
            Message = $"WARNING: {nameof(ReadAllBytes)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllBytes($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllBytes($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllBytes($args$)",
            Message = $"WARNING: {nameof(ReadAllBytes)} is obsolete")]
        public static byte[] ReadAllBytes(string path)
        {
            Assert.FileExists(path);
            return File.ReadAllBytes(path);
        }
    }
}
