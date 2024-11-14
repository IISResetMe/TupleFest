using TupleFest;

REPL.Run();

namespace TupleFest
{
    using System.Globalization;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using static System.Console;
    
    public static class REPL {
        internal static class Theme {
            public static readonly ConsoleColor Prompt = ConsoleColor.Magenta;
            public static readonly ConsoleColor Input = ConsoleColor.DarkCyan;
            public static readonly ConsoleColor Error = ConsoleColor.Red;
            public static readonly ConsoleColor Output = ConsoleColor.White;
            public static readonly ConsoleColor Help = ConsoleColor.Gray;
        }

        private static string Results = string.Empty;
        private static Exception? LastException = null;

        public enum Outcome {
            Exit,
            Print,
            Continue,
            Error,
            PrintUsage
        }

        private static readonly string[] s_exitKeywords = ["quit", "exit"];
        private static readonly string s_usageText = @"
        Usage:

            [command] [...args]

        Commands:
            bm          - Run full benchmark suite
            flat [n]    - Instantiate flat tuple fitting [n] items
            branch [n]  - Instantiate branching tuple fitting [n] items

        ";

        public static void Run() {
            Outcome outcome;
            do {
                string input = Read();
                outcome = Evaluate(input);
                if (outcome == Outcome.Continue) {
                    continue;
                }
                if (outcome == Outcome.Error) {
                    try {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Error!");
                        if (LastException is not null) {
                            WriteLine(LastException.Message);
                            WriteLine(LastException.StackTrace);
                        }
                        else {
                            WriteLine("Unknown error...");
                            outcome = Outcome.Exit;
                        }
                    }
                    finally {
                        ResetColor();
                    }
                }
                if (outcome == Outcome.Print || outcome == Outcome.PrintUsage) {
                    try {
                        ForegroundColor = Theme.Output;
                        WriteLine(Results);
                        if (outcome == Outcome.PrintUsage){
                            ForegroundColor = Theme.Help;
                            WriteLine(s_usageText);
                        }
                    }
                    finally {
                        ResetColor();
                    }
                }
                if (outcome == Outcome.Exit) {
                    WriteLine("Exiting...");
                }
            } while (outcome != Outcome.Exit);
        }

        public static string Read(){
            try {
                ForegroundColor = Theme.Prompt;
                Write(" > ");
                ForegroundColor = Theme.Input;
                return ReadLine() ?? string.Empty;
            }
            finally {
                ResetColor();
            }
        }

        public static Outcome Evaluate(string input) {
            if (string.IsNullOrWhiteSpace(input)) {
                return Outcome.Continue;
            }
            input = input.Trim();

            if (s_exitKeywords.Any(c => c.StartsWith(input))) {
                return Outcome.Exit;
            }

            if ((input.StartsWith("flat ") || input.StartsWith("branch ")) && int.TryParse(input.Split(" ")[1], out int ac)) {
                var tfbm = new TupleFestBenchMark
                {
                    ArgsCount = ac
                };
                try {
                    tfbm.ArgsCount = ac;
                    if (input.StartsWith('f')) {
                        tfbm.TestFlatTuple();
                    }
                    else {
                        tfbm.TestBranchingTuple();
                    }
                    Results = string.Create(CultureInfo.InvariantCulture, $"Tested flat tuple with {ac} args");
                }
                catch (Exception exc) {
                    LastException = exc;
                    return Outcome.Error;
                }
                return Outcome.Print;
            }

            if (input == "bm") {
                try {
                    BenchmarkRunner.Run<TupleFestBenchMark>();
                }
                catch (Exception exc) {
                    LastException = exc;
                    return Outcome.Error;
                }
                return Outcome.Print;
            }

            Results = string.Create(CultureInfo.InvariantCulture, $"Unknown command '{input}'");
            return Outcome.PrintUsage;
        } 
    }

    enum TupleKind 
    {
        Flat,
        Branching
    }

    public static class Extensions {
        public static void ThrowIfOutside(this int value, int lowInclude, int highInclude) {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, lowInclude);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, highInclude);
        }
    }

    public class TupleFestBenchMark
    {
        private static (Type, int) MakeTupleType(int argCount, TupleKind kind) {
            argCount.ThrowIfOutside(1, 128);

            if (kind == TupleKind.Flat) {
                if (argCount <= 1) {
                    return (typeof(FlatTuple<>).MakeGenericType([typeof(object)]), argCount);
                }

                if (argCount <= 2) {
                    return (typeof(FlatTuple<,>).MakeGenericType([typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 3) {
                    return (typeof(FlatTuple<,,>).MakeGenericType([typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 4) {
                    return (typeof(FlatTuple<,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 5) {
                    return (typeof(FlatTuple<,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 6) {
                    return (typeof(FlatTuple<,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 7) {
                    return (typeof(FlatTuple<,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 8) {
                    return (typeof(FlatTuple<,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 9) {
                    return (typeof(FlatTuple<,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 10) {
                    return (typeof(FlatTuple<,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 11) {
                    return (typeof(FlatTuple<,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 12) {
                    return (typeof(FlatTuple<,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 13) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 14) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 15) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 16) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 17) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 18) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 19) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 20) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 21) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 22) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 23) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 24) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 25) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 26) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 27) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 28) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 29) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 30) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 31) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 32) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), argCount);
                }

                if (argCount <= 64) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 64);
                }

                if (argCount <= 128) {
                    return (typeof(FlatTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 128);
                }
            }
            else {
                if (argCount <= 1) {
                    return (typeof(BranchingTuple<>).MakeGenericType([typeof(object)]), 1);
                }

                if (argCount <= 2) {
                    return (typeof(BranchingTuple<,>).MakeGenericType([typeof(object), typeof(object)]), 2);
                }

                if (argCount <= 4) {
                    return (typeof(BranchingTuple<,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object)]), 4);
                }

                if (argCount <= 8) {
                    return (typeof(BranchingTuple<,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 8);
                }

                if (argCount <= 16) {
                    return (typeof(BranchingTuple<,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 16);
                }

                if (argCount <= 32) {
                    return (typeof(BranchingTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 32);
                }

                if (argCount <= 64) {
                    return (typeof(BranchingTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 64);
                }

                if (argCount <= 128) {
                    return (typeof(BranchingTuple<,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,>).MakeGenericType([typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object), typeof(object)]), 128);
                }
            }

            throw new InvalidOperationException("");
        }

        [Params(8,9,10,11,12,13,14,15,16,17,32)]
        public int ArgsCount { get; set; }

        public Action<object?> Action { get; set; } = _ => {};

        [Benchmark]
        public void TestBranchingTuple(){
            Test(TupleKind.Branching);
        }

        [Benchmark]
        public void TestFlatTuple(){
            Test(TupleKind.Flat);
        }

        private void Test(TupleKind kind) {
            (Type type, int size) = MakeTupleType(ArgsCount, kind);
            var args = new object[size];
            for (int i = 0; i < args.Length; i++) {
                args[i] = new object();
            }
            var tuple = (CommonTuple)Activator.CreateInstance(type, args: args);
            tuple.Traverse(_ => {});
        }
    }
}