using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReservavel  {

    void SetReserva(IReservaDeObjetos reserva);
    void AoEntrarNaReserva();
    void AoSairDaReserva();

}
