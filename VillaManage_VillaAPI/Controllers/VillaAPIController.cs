using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VillaManage_VillaAPI.Data;
using VillaManage_VillaAPI.Logging;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Model.DTO;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : Controller
    {
        //private readonly ILogging logger;   // Using for log action
        //private readonly ApplicationDbContext _context;   // using for get data from context when not using Repository
        protected APIResponse _response;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;

        public VillaAPIController(/*/*ILogging _logger, ApplicationDbContext context*/IVillaRepository dbVilla, IMapper mapper)
        {
            //logger = _logger;
            //_context = context;
             _dbVilla = dbVilla;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<APIResponse>>> GetVillas()   /*VillaDTO*/
        {
            try
            {
                //logger.Log("Getting all villas","");
                //return Ok(await _context.Villas.ToListAsync());  without Mapper
                IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync(); /*=== _context.Villas.ToListAsync()*/
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);/* _mapper.Map<List<VillaDTO>>(villaList)*/
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessagess = new List<string>() { ex.ToString() };
            }
            return Ok(_response);

        }
        [HttpGet("{id:int}",Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
      //[ProducesResponseType(200) , Type= typeof(VillaDTO)]
      //[ProducesResponseType(404)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    //logger.Log("Get Villa Error with Id =" + id,"error");
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villa = await _dbVilla.GetAsync((u => u.Id == id));/*===  _context.Villas.FirstOrDefaultAsync*/
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<List<VillaDTO>>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessagess = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
            //return Ok(_mapper.Map<VillaDTO>(villa));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDTO createVillaDTO) 
        {
            try
            {
                //if (!ModelState.IsValid) 
                //{
                //    return BadRequest(ModelState);
                //}

                if (await _dbVilla.GetAsync(u => u.Name.ToLower() == createVillaDTO.Name.ToLower()) != null) /*===  _context.Villas.FirstOrDefaultAsync*/
                {
                    ModelState.AddModelError("CustomerError", "Villa already exists");
                }
                if (createVillaDTO == null)
                {
                    return BadRequest(createVillaDTO);
                }
                //if (villaDTO.Id > 0)
                // {
                //     return StatusCode(StatusCodes.Status500InternalServerError);
                // }
                //Villa model = new()
                //{
                //    Amenity = createVillaDTO.Amenity,
                //    Details = createVillaDTO.Details,
                //    //Id = villaDTO.Id,
                //    ImageUrl = createVillaDTO.ImageUrl,
                //    Name = createVillaDTO.Name,
                //    Occupancy = createVillaDTO.Occupancy,
                //    Rate = createVillaDTO.Rate,
                //    Sqft = createVillaDTO.Sqft,
                //};
                Villa villa = _mapper.Map<Villa>(createVillaDTO);

                await _dbVilla.CreateAsync(villa); /*=== _context.Villas.AddAsync*/
                _response.Result = _mapper.Map<List<VillaDTO>>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                //await _dbVillaNumber.SaveAsync();
                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessagess = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }


        [HttpDelete("{id=int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _dbVilla.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }

                _dbVilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                //await _dbVillaNumber.SaveAsync();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessagess = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateVillaDTO)
        {
            try
            {


                if (updateVillaDTO == null || id != updateVillaDTO.Id)
                {
                    return BadRequest();
                }
                //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
                //villa.Name = villaDTO.Name;
                //villa.Sqft = villaDTO.Sqft;
                //villa.Occupancy = villaDTO.Occupancy;

                //Villa model = new()
                //{
                //    Amenity = updateVillaDTO.Amenity,
                //    Details = updateVillaDTO.Details,
                //    Id = updateVillaDTO.Id,
                //    ImageUrl = updateVillaDTO.ImageUrl,
                //    Name = updateVillaDTO.Name,
                //    Occupancy = updateVillaDTO.Occupancy,
                //    Rate = updateVillaDTO.Rate,
                //    Sqft = updateVillaDTO.Sqft,
                //};
                Villa model = _mapper.Map<Villa>(updateVillaDTO);

                _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessagess = new List<string>() { ex.ToString() };
            }

            return Ok(_response);
        }
            [HttpPatch("{id:int}", Name = "UpdatePatchVilla")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
            {
   
                if (patchDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var villa = await _dbVilla.GetAsync(u => u.Id == id, tracked: false);/*=== _context.Villas.AsNoTracking().FirstOrDefaultAsync*/
                VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
                //VillaUpdateDTO villaDTO = new()
                //{
                //    Amenity = villa.Amenity,
                //    Details = villa.Details,
                //    Id = villa.Id,
                //    ImageUrl = villa.ImageUrl,
                //    Name = villa.Name,
                //    Occupancy = villa.Occupancy,
                //    Rate = villa.Rate,
                //    Sqft = villa.Sqft,
                //};  

                if (villa == null)
                {
                    return BadRequest();
                }
                patchDTO.ApplyTo(villaDTO, ModelState);
                Villa model = _mapper.Map<Villa>(villaDTO);

                //Villa model = new()
                //{
                //    Amenity = villaDTO.Amenity,
                //    Details = villaDTO.Details,
                //    Id = villaDTO.Id,
                //    ImageUrl = villaDTO.ImageUrl,
                //    Name = villaDTO.Name,
                //    Occupancy = villaDTO.Occupancy,
                //    Rate = villaDTO.Rate,
                //    Sqft = villaDTO.Sqft,
                //};
                _dbVilla.UpdateAsync(model);
                await _dbVilla.SaveAsync();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                return NoContent();
            }
        }

    }
