package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@Table(name="ssak")
public class Ssak extends Zwierze{
    private Boolean czy_wlosy;

    public Boolean getCzy_wlosy() {
        return czy_wlosy;
    }

    public void setCzy_wlosy(Boolean czy_wlosy) {
        this.czy_wlosy = czy_wlosy;
    }
}
