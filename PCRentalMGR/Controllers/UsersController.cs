using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCRentalMGR.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCRentalMGR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PCRentalMGRContext _context;

        public UsersController(PCRentalMGRContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // Usersテーブルから全てのユーザー情報を取得
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // 特定のユーザーIDに基づくユーザー情報を取得
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(); // ユーザーが見つからない場合、404エラーを返す
            }

            return user;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            // モデルの状態が正しいかどうかを確認
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // モデルが不正な場合は400エラーを返す
            }

            // 新しいユーザーをデータベースに追加
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // 新しく作成されたユーザーを返す
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest(); // リクエストされたIDが一致しない場合は400エラーを返す
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound(); // ユーザーが存在しない場合は404エラーを返す
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // 成功した場合は204 No Contentを返す
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(); // ユーザーが見つからない場合は404エラーを返す
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent(); // 成功した場合は204 No Contentを返す
        }

        // ユーザーが存在するかどうかを確認
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
