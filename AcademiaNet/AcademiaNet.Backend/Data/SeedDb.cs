using Microsoft.EntityFrameworkCore;

namespace AcademiaNet.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckInstitutionsAsync();
            await CheckRolesAsync();
            await CheckUsersAsync();
            await CheckAcademicProgramsAsync();
            await CheckEnrollmentPeriodsAsync();
            await CheckExamsAsync();
            await CheckEnrollmentAsync();
            await CheckExamResultAsync();
            await CheckNotificationAsync();
            await CheckPeriodAcademicProgramsAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckInstitutionsAsync()
        {
            if (!_context.Institutions.Any())
            {
                var institutionsSQLScript = File.ReadAllText("Data\\Institutions.sql");
                await _context.Database.ExecuteSqlRawAsync(institutionsSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckRolesAsync()
        {
            if (!_context.Roles.Any())
            {
                var rolesSQLScript = File.ReadAllText("Data\\Roles.sql");
                await _context.Database.ExecuteSqlRawAsync(rolesSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>

        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                var usersSQLScript = File.ReadAllText("Data\\Users.sql");
                await _context.Database.ExecuteSqlRawAsync(usersSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckAcademicProgramsAsync()
        {
            if (!_context.AcademicPrograms.Any())
            {
                var academicProgramsSQLScript = File.ReadAllText("Data\\AcademicPrograms.sql");
                await _context.Database.ExecuteSqlRawAsync(academicProgramsSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckEnrollmentPeriodsAsync()
        {
            if (!_context.EnrollmentPeriods.Any())
            {
                var enrollmentPeriodsSQLScript = File.ReadAllText("Data\\EnrollmentPeriods.sql");
                await _context.Database.ExecuteSqlRawAsync(enrollmentPeriodsSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckExamsAsync()
        {
            if (!_context.Exams.Any())
            {
                var examsSQLScript = File.ReadAllText("Data\\Exams.sql");
                await _context.Database.ExecuteSqlRawAsync(examsSQLScript);
            }
        }

        /// <summary>
        /// ----------------------------------------?
        /// </summary>
        /// <returns></returns>
        private async Task CheckEnrollmentAsync()
        {
            if (!_context.Enrollments.Any())
            {
                var enrollmentSQLScript = File.ReadAllText("Data\\Enrollments.sql");
                await _context.Database.ExecuteSqlRawAsync(enrollmentSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckExamResultAsync()
        {
            if (!_context.ExamResults.Any())
            {
                var examResultsSQLScript = File.ReadAllText("Data\\ExamResults.sql");
                await _context.Database.ExecuteSqlRawAsync(examResultsSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckNotificationAsync()
        {
            if (!_context.Notifications.Any())
            {
                var notificationsSQLScript = File.ReadAllText("Data\\Notifications.sql");
                await _context.Database.ExecuteSqlRawAsync(notificationsSQLScript);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private async Task CheckPeriodAcademicProgramsAsync()
        {
            if (!_context.PeriodAcademicPrograms.Any())
            {
                var periodAcademicProgramsSQLScript = File.ReadAllText("Data\\PeriodAcademicPrograms.sql");
                await _context.Database.ExecuteSqlRawAsync(periodAcademicProgramsSQLScript);
            }
        }
    }
}