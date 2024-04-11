package pl.opole.uni.lista1.model;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;

@Entity
@Table(name="traktor")
public class Traktor extends Pojazd{
    private Boolean czy_kabina;
    private Integer moc;

    public Boolean getCzy_kabina() {
        return czy_kabina;
    }

    public void setCzy_kabina(Boolean czy_kabina) {
        this.czy_kabina = czy_kabina;
    }

    public Integer getMoc() {
        return moc;
    }

    public void setMoc(Integer moc) {
        this.moc = moc;
    }
}
