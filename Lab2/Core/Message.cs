using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Core;

public record Message(ValidString Title, ValidString Body, MessageImportance Importance);