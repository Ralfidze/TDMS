using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public partial class TRole
{
    /// <summary>
    /// Главный инженер
    /// </summary>
    public const int MAIN = 1;
    
    /// <summary>
    /// Отдел планирования ПИР
    /// </summary>
    public const int PROJECT_PLAN = 2;

    /// <summary>
    /// Курирующий отдел
    /// </summary>
    public const int SUPERVISOR = 3;

    /// <summary>
    /// Экспертный отдел
    /// </summary>
    public const int EXAMINATOR = 4;

    /// <summary>
    /// Проектно сметный отдел
    /// </summary>
    public const int PROJECT_DOC = 5;

    /// <summary>
    /// Подрядчик
    /// </summary>
    public const int BUILDER = 6;
}