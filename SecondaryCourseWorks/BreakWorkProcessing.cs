namespace SecondaryCourseWorks.GotoException;

// Используется как goto: прерывает обработку Execute работы, если был ввод break в Input
internal class BreakWorkProcessing : Exception;
internal class ProgrammExit : Exception;