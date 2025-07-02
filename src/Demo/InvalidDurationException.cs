using Baked.ExceptionHandling;

namespace Demo;

public class InvalidDurationException(DateTime beginning, DateTime ending)
    : HandledException($"Beginning ({beginning}) should be before ending ({ending})",
        extraData: new()
        {
            [nameof(beginning)] = beginning,
            [nameof(ending)] = ending
        }
    );
