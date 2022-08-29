﻿// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    public static class SolutionModelTasks
    {
        public static Solution CreateSolution(string fileName = null, params Solution[] solutions)
        {
            return CreateSolution(fileName, solutions, folderNameProvider: null);
        }

        public static Solution CreateSolution(
            string fileName = null,
            IEnumerable<Solution> solutions = null,
            Func<Solution, string> folderNameProvider = null,
            bool randomizeProjectIds = true)
        {
            Assert.True(folderNameProvider != null || solutions != null);

            var solution = SolutionSerializer.DeserializeFromContent<Solution>(
                new[]
                {
                    "Microsoft Visual Studio Solution File, Format Version 12.00",
                    "# Visual Studio 15",
                    "VisualStudioVersion = 15.0.26124.0",
                    "MinimumVisualStudioVersion = 15.0.26124.0"
                },
                fileName);

            solution.Configurations = new Dictionary<string, string>
                                      {
                                          { "Debug|Any CPU", "Debug|Any CPU" },
                                          { "Release|Any CPU", "Release|Any CPU" }
                                      };

            solutions?.ForEach(x =>
            {
                var folder = folderNameProvider != null && folderNameProvider(x) is { } folderName
                    ? solution.AddSolutionFolder(folderName)
                    : null;

                solution.AddSolution(x, folder);

                if (randomizeProjectIds)
                    solution.RandomizeProjectIds();
            });

            return solution;
        }

        public static Solution ParseSolution(string solutionFile)
        {
            return SolutionSerializer.DeserializeFromFile<Solution>(solutionFile);
        }

        public static Solution ReadSolution([NotNull] this AbsolutePath path)
        {
            return ParseSolution(path);
        }
    }
}
