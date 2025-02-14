using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VillaManage_VillaAPI.Model.DTO;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Repository.IRepository;

namespace VillaManage_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
        public class VillaNumberAPIController : Controller
        {
            protected APIResponse _response;
            private readonly IVillaNumberRepository _dbVillaNumber;
            private readonly IVillaRepository _dbVilla;
            private readonly IMapper _mapper;

            public VillaNumberAPIController(IVillaNumberRepository dbVillaNumber, IMapper mapper, IVillaRepository dbvilla)
            {
                _dbVillaNumber = dbVillaNumber;
                _mapper = mapper;
            _dbVilla = dbvilla;
                this._response = new();
            }

            [HttpGet]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<APIResponse>>> GetVillaNumbers()   
            {
                try
                {
                if (_dbVillaNumber == null)
                {
                    throw new Exception("_dbVillaNumber is null");
                }
                if (_mapper == null)
                {
                    throw new Exception("_mapper is null");
                }
         
                IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync(); 
                    _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessagess = new List<string>() { ex.ToString() };
                }
                return Ok(_response);

            }
            [HttpGet("{id:int}", Name = "GetVillaNumber")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
            {
                try
                {
                    if (id == 0)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(_response);
                    }
                    var villa = await _dbVillaNumber.GetAsync((u => u.VillaNo == id));
                    if (villa == null)
                    {
                        _response.StatusCode = HttpStatusCode.NotFound;
                        return NotFound(_response);
                    }
                    _response.Result = _mapper.Map<List<VillaNumberDTO>>(villa);
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessagess = new List<string>() { ex.ToString() };
                }
                return Ok(_response);
            }
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createVillaNumberDTO)
            {
                try
                {
                if (await _dbVillaNumber.GetAsync(u => u.VillaNo == createVillaNumberDTO.VillaNo) != null)
                    {
                        ModelState.AddModelError("CustomerError", "Villa Number already exists");
                       return BadRequest(ModelState);
                }
                if(await _dbVilla.GetAsync(u=>u.Id == createVillaNumberDTO.VillaID) == null)
                {
                    ModelState.AddModelError("CustomerError", "Villa Id is Invalid");
                    return BadRequest(ModelState);
                }
                    if (createVillaNumberDTO == null)
                    {
                        return BadRequest(createVillaNumberDTO);
                    }

                    VillaNumber villaNumber = _mapper.Map<VillaNumber>(createVillaNumberDTO);

                    await _dbVillaNumber.CreateAsync(villaNumber); 
                    _response.Result = _mapper.Map<List<VillaDTO>>(villaNumber);
                    _response.StatusCode = HttpStatusCode.Created;
                    return CreatedAtRoute("GetVilla", new { id = villaNumber.VillaNo }, _response);
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessagess = new List<string>() { ex.ToString() };
                }
                return Ok(_response);
            }


            [HttpDelete("{id=int}", Name = "DeleteVillaNumber")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
            {
                try
                {
                    if (id == 0)
                    {
                        return BadRequest();
                    }
                    var villaNumber = await _dbVillaNumber.GetAsync(u => u.VillaNo == id);
                    if (villaNumber == null)
                    {
                        return NotFound();
                    }

                    _dbVillaNumber.RemoveAsync(villaNumber);
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

            [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateVillaNumberDTO)
            {
                try
                {


                    if (updateVillaNumberDTO == null || id != updateVillaNumberDTO.VillaNo)
                    {
                        return BadRequest();
                    }
                if (await _dbVilla.GetAsync(u => u.Id == updateVillaNumberDTO.VillaID) == null)
                {
                    ModelState.AddModelError("CustomerError", "Villa Id is Invalid");
                    return BadRequest(ModelState);
                }

                VillaNumber model = _mapper.Map<VillaNumber>(updateVillaNumberDTO);

                    _dbVillaNumber.UpdateAsync(model);
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
        }
    }
