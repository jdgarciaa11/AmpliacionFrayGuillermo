using Ampliacion_FrayGuillermo.Models.Entities;

namespace Ampliacion_FrayGuillermo.Models.ViewModels
{
    public class clsIndexVM
    {
        #region Atributos Privados
        private List<clsCategoria> listadoCategoria;
        private List<clsPlanta> listaPlanta;
        #endregion

        #region Propiedades Publicas
        public List<clsCategoria> ListadoCategoria
        {
            get
            {
                listadoCategoria = clsListadoCategorias.listadoCategoriaCompleto();
                return listadoCategoria;
            }
        }
        public List<clsPlanta> ListaPlanta
        {
            get
            {
                listaPlanta = clsListadoPlantas.listadoPlantaCompleto();
                return listaPlanta;
            }
        }
        #endregion


        #region Constructores
        public clsIndexVM()
        {
        }
        #endregion



    }
}
